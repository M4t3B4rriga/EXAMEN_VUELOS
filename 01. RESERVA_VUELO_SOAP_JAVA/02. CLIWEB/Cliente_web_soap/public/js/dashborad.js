// URL del proxy y del servicio SOAP
const proxyUrl = 'http://localhost:3000/soap';

const soapEndpoint = 'http://10.40.26.45:8080/Reservas_vuelos/WSVuelo?wsdl';


// Obtener el email del usuario desde sessionStorage
const email = sessionStorage.getItem('email');
document.getElementById('userEmail').textContent = `Usuario: ${email}`;

// Función para parsear XML a tabla HTML
function parseXMLToTable(xmlText, type) {
  try {
    console.log(`Raw XML Response (${type}):`, xmlText); // Debug: Log raw XML

    const parser = new DOMParser();
    const xmlDoc = parser.parseFromString(xmlText, 'text/xml');

    // Helper function to get tag value, handling namespaces
    const getTagValue = (element, tagName) => {
      let nodes = element.getElementsByTagName(tagName);
      if (nodes.length === 0) {
        // Try with any namespace
        nodes = element.getElementsByTagNameNS('*', tagName.split(':').pop());
      }
      return nodes[0]?.textContent || 'N/A';
    };

    // Debug: Log all tags in an element
    const debugElement = (element, type) => {
      const tags = Array.from(element.getElementsByTagName('*')).map(node => ({
        tagName: node.tagName,
        value: node.textContent || 'N/A'
      }));
      console.log(`Tags in ${type} element:`, tags);
    };

    let table = '<table><thead><tr>';
    let rows = '';

    if (type === 'vuelos') {
      const vuelos = xmlDoc.getElementsByTagName('vuelo');
      if (vuelos.length === 0) {
        console.log('No vuelos found in XML. Checking all tags...');
        const allTags = Array.from(xmlDoc.getElementsByTagName('*')).map(node => node.tagName);
        console.log('All tags in XML:', allTags);
        return '<p class="error">No se encontraron vuelos. Verifica la respuesta XML en la consola.</p>';
      }

      // Debug: Log tags in the first vuelo
      if (vuelos[0]) debugElement(vuelos[0], 'vuelo');

      const headers = ['ID Vuelo', 'Origen', 'Destino', 'Fecha', 'Hora', 'Precio', 'Asientos Disponibles'];
      headers.forEach(header => table += `<th>${header}</th>`);
      table += '</tr></thead><tbody>';

      for (let vuelo of vuelos) {
        const id = getTagValue(vuelo, 'idVuelo');
        const origen = getTagValue(vuelo, 'ciudadOrigen');
        const destino = getTagValue(vuelo, 'ciudadDestino');
        // Extract date from horaSalida (e.g., '2025-06-01T10:30:00-05:00' -> '2025-06-01')
        const fecha = getTagValue(vuelo, 'horaSalida').split('T')[0];
        // Extract time from horaSalida (e.g., '2025-06-01T10:30:00-05:00' -> '10:30')
        const hora = getTagValue(vuelo, 'horaSalida').split('T')[1]?.split('-')[0] || 'N/A';
        const precio = getTagValue(vuelo, 'valor');
        const asientosDisponibles = getTagValue(vuelo, 'asientosDisponibles');
        rows += `<tr><td>${id}</td><td>${origen}</td><td>${destino}</td><td>${fecha}</td><td>${hora}</td><td>${precio}</td><td>${asientosDisponibles}</td></tr>`;
      }
    } else if (type === 'boletos') {
      const boletos = xmlDoc.getElementsByTagName('boleto');
      if (boletos.length === 0) {
        console.log('No boletos found in XML. Checking all tags...');
        const allTags = Array.from(xmlDoc.getElementsByTagName('*')).map(node => node.tagName);
        console.log('All tags in XML:', allTags);
        return '<p class="error">No se encontraron boletos. Verifica la respuesta XML en la consola.</p>';
      }

      // Debug: Log tags in the first boleto
      if (boletos[0]) debugElement(boletos[0], 'boleto');

      const headers = ['ID Boleto', 'ID Vuelo', 'Asientos', 'Fecha Compra'];
      headers.forEach(header => table += `<th>${header}</th>`);
      table += '</tr></thead><tbody>';

      for (let boleto of boletos) {
        const id = getTagValue(boleto, 'idBoleto');
        const idVuelo = getTagValue(boleto, 'idVuelo');
        const asientos = getTagValue(boleto, 'numeroAsiento');
        const fechaCompra = getTagValue(boleto, 'fechaCompra');
        rows += `<tr><td>${id}</td><td>${idVuelo}</td><td>${asientos}</td><td>${fechaCompra}</td></tr>`;
      }
    } else if (type === 'compra') {
      const mensaje = getTagValue(xmlDoc, 'mensaje') || 'Compra realizada con éxito.';
      return `<p>${mensaje}</p>`;
    }

    table += rows + '</tbody></table>';
    return table;
  } catch (e) {
    console.error('Error parsing XML:', e);
    return `<p class="error">Error al procesar la respuesta: ${e.message}. Verifica la consola para más detalles.</p>`;
  }
}

// Función para obtener el ID del usuario por email
async function obtenerIdUsuarioPorEmail(email) {
  const xml = `
    <soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:con="http://controller.monster.edu.ec/">
      <soapenv:Header/>
      <soapenv:Body>
        <con:obtenerIdUsuarioPorEmail>
          <email>${email}</email>
        </con:obtenerIdUsuarioPorEmail>
      </soapenv:Body>
    </soapenv:Envelope>
  `;

  const response = await fetch(proxyUrl, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({
      endpoint: soapEndpoint,
      soapAction: '',
      xmlBody: xml
    })
  });

  const text = await response.text();
  console.log('obtenerIdUsuarioPorEmail Response:', text); // Debug
  const parser = new DOMParser();
  const xmlDoc = parser.parseFromString(text, 'text/xml');
  const idUsuario = xmlDoc.getElementsByTagName('idUsuario')[0]?.textContent || '';
  if (!idUsuario) console.log('No idUsuario found in response');
  return idUsuario;
}

// Función para buscar vuelos
async function buscarVuelos(ciudadOrigen, ciudadDestino, fecha) {
  const xml = `
    <soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:con="http://controller.monster.edu.ec/">
      <soapenv:Header/>
      <soapenv:Body>
        <con:buscarVuelos>
          <ciudadOrigen>${ciudadOrigen}</ciudadOrigen>
          <ciudadDestino>${ciudadDestino}</ciudadDestino>
          <fecha>${fecha}</fecha>
        </con:buscarVuelos>
      </soapenv:Body>
    </soapenv:Envelope>
  `;

  const response = await fetch(proxyUrl, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({
      endpoint: soapEndpoint,
      soapAction: '',
      xmlBody: xml
    })
  });

  const text = await response.text();
  document.getElementById('resultado').innerHTML = parseXMLToTable(text, 'vuelos');
}

// Función para mostrar todos los vuelos
async function mostrarTodosVuelos() {
  const xml = `
    <soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:con="http://controller.monster.edu.ec/">
      <soapenv:Header/>
      <soapenv:Body>
        <con:mostrarTodosVuelos/>
      </soapenv:Body>
    </soapenv:Envelope>
  `;

  const response = await fetch(proxyUrl, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({
      endpoint: soapEndpoint,
      soapAction: '',
      xmlBody: xml
    })
  });

  const text = await response.text();
  document.getElementById('resultado').innerHTML = parseXMLToTable(text, 'vuelos');
}

// Función para mostrar boletos del usuario
async function mostrarBoletosUsuario() {
  const idUsuario = await obtenerIdUsuarioPorEmail(email);
  if (!idUsuario) {
    document.getElementById('resultado').innerHTML = '<p class="error">Error: No se pudo obtener el ID del usuario.</p>';
    return;
  }

  const xml = `
    <soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:con="http://controller.monster.edu.ec/">
      <soapenv:Header/>
      <soapenv:Body>
        <con:mostrarBoletosUsuario>
          <idUsuario>${idUsuario}</idUsuario>
        </con:mostrarBoletosUsuario>
      </soapenv:Body>
    </soapenv:Envelope>
  `;

  const response = await fetch(proxyUrl, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({
      endpoint: soapEndpoint,
      soapAction: '',
      xmlBody: xml
    })
  });

  const text = await response.text();
  document.getElementById('resultado').innerHTML = parseXMLToTable(text, 'boletos');
}

// Función para comprar boletos
async function comprarBoletos(idVuelo, numeroAsientos) {
  const idUsuario = await obtenerIdUsuarioPorEmail(email);
  if (!idUsuario) {
    document.getElementById('resultado').innerHTML = '<p class="error">Error: No se pudo obtener el ID del usuario.</p>';
    return;
  }

  const xml = `
    <soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:con="http://controller.monster.edu.ec/">
      <soapenv:Header/>
      <soapenv:Body>
        <con:comprarBoletos>
          <idUsuario>${idUsuario}</idUsuario>
          <idVuelo>${idVuelo}</idVuelo>
          <numeroAsientos>${numeroAsientos}</numeroAsientos>
        </con:comprarBoletos>
      </soapenv:Body>
    </soapenv:Envelope>
  `;

  const response = await fetch(proxyUrl, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({
      endpoint: soapEndpoint,
      soapAction: '',
      xmlBody: xml
    })
  });

  const text = await response.text();
  document.getElementById('resultado').innerHTML = parseXMLToTable(text, 'compra');
}

// Determinar la página actual y asociar event listeners
const currentPage = window.location.pathname.split('/').pop();
if (currentPage === 'buscar-vuelos.html') {
  document.getElementById('buscarVuelosForm').addEventListener('submit', (e) => {
    e.preventDefault();
    const ciudadOrigen = document.getElementById('ciudadOrigen').value;
    const ciudadDestino = document.getElementById('ciudadDestino').value;
    const fecha = document.getElementById('fecha').value;
    buscarVuelos(ciudadOrigen, ciudadDestino, fecha);
  });
} else if (currentPage === 'todos-vuelos.html') {
  document.getElementById('mostrarTodosVuelosBtn').addEventListener('click', () => {
    mostrarTodosVuelos();
  });
} else if (currentPage === 'mis-boletos.html') {
  document.getElementById('mostrarBoletosBtn').addEventListener('click', () => {
    mostrarBoletosUsuario();
  });
} else if (currentPage === 'comprar-boletos.html') {
  document.getElementById('comprarBoletosForm').addEventListener('submit', (e) => {
    e.preventDefault();
    const idVuelo = document.getElementById('idVuelo').value;
    const numeroAsientos = document.getElementById('numeroAsientos').value;
    comprarBoletos(idVuelo, numeroAsientos);
  });
}

// Toggle Sidebar
document.getElementById('toggleSidebar').addEventListener('click', () => {
  const sidebar = document.getElementById('sidebar');
  sidebar.classList.toggle('sidebar-hidden');
});

// Show sidebar by default on larger screens
if (window.innerWidth >= 768) {
  document.getElementById('sidebar').classList.remove('sidebar-hidden');
}