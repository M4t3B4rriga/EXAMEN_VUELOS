<<<<<<< HEAD
// URL del proxy y del servicio SOAP
const proxyUrl = 'http://localhost:3000/soap';
const soapEndpoint = 'http://10.40.26.45:8080/Reservas_vuelos/WSVuelo?wsdl';

// Reusable function to send SOAP requests
async function sendSoapRequest(xml) {
  try {
    const response = await fetch(proxyUrl, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({
        endpoint: soapEndpoint,
        soapAction: '',
        xmlBody: xml
      })
    });
    return await response.text();
  } catch (e) {
    console.error('Error en SOAP request:', e);
    return `<p class="error">Error de conexión: ${e.message}</p>`;
  }
}

// Helper function to safely update resultado div
function updateResultado(message, isError = false) {
  const resultado = document.getElementById('resultado');
  if (resultado) {
    resultado.innerHTML = `<p class="${isError ? 'error text-red-500' : 'text-green-500'}">${message}</p>`;
  } else {
    console.error('Elemento con id "resultado" no encontrado en el DOM');
    alert(message); // Fallback to alert if resultado div is missing
  }
}

// Handle login
async function handleLogin(email, contrasena) {
  const xml = `
    <soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:con="http://controller.monster.edu.ec/">
      <soapenv:Header/>
      <soapenv:Body>
        <con:login>
          <email>${email}</email>
          <contrasena>${contrasena}</contrasena>
        </con:login>
      </soapenv:Body>
    </soapenv:Envelope>
  `;

  const text = await sendSoapRequest(xml);
  console.log('Login response:', text); // Debug: Log SOAP response
=======
document.getElementById('loginForm').addEventListener('submit', async (e) => {
  e.preventDefault();
  const email = document.getElementById('email').value;
  const contrasena = document.getElementById('password').value;

  const xml = `
  <soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:con="http://controller.monster.edu.ec/">
    <soapenv:Header/>
    <soapenv:Body>
      <con:login>
        <email>${email}</email>
        <contrasena>${contrasena}</contrasena>
      </con:login>
    </soapenv:Body>
  </soapenv:Envelope>`;

  const response = await fetch('http://localhost:3000/soap', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({
      endpoint: 'http://192.168.0.102:8080/Reservas_vuelos/WSVuelo?wsdl',
      soapAction: '',
      xmlBody: xml
    })
  });

  const text = await response.text();
>>>>>>> 47a79e34fec662558b14e38ab589974b0a06d8e4
  if (text.includes('true')) {
    sessionStorage.setItem('email', email);
    location.href = 'comprar-boletos.html';
  } else {
<<<<<<< HEAD
    updateResultado('Credenciales incorrectas', true);
  }
}

// Handle registration
async function handleRegister(nombre, apellido, cedula, celular, email, contrasena) {
  const xml = `
    <soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:con="http://controller.monster.edu.ec/">
      <soapenv:Header/>
      <soapenv:Body>
        <con:registrarUsuario>
          <nombreUsuario>${nombre}</nombreUsuario>
          <apellidoUsuario>${apellido}</apellidoUsuario>
          <cedula>${cedula}</cedula>
          <celular>${celular}</celular>
          <email>${email}</email>
          <contrasena>${contrasena}</contrasena>
        </con:registrarUsuario>
      </soapenv:Body>
    </soapenv:Envelope>
  `;

  const text = await sendSoapRequest(xml);
  console.log('Register response:', text); // Debug
  if (text.includes('true') || text.includes('success')) {
    updateResultado('Registro exitoso. <a href="login.html" class="text-blue-600 underline">Inicia sesión</a>');
  } else {
    updateResultado('Error en el registro. Verifica los datos.', true);
  }
}

// Determine the current page and attach event listeners
const currentPage = window.location.pathname.split('/').pop();
if (currentPage === 'login.html') {
  const loginForm = document.getElementById('loginForm');
  if (loginForm) {
    loginForm.addEventListener('submit', async (e) => {
      e.preventDefault();
      const email = document.getElementById('email').value;
      const contrasena = document.getElementById('password').value;
      await handleLogin(email, contrasena);
    });
  } else {
    console.error('Elemento con id "loginForm" no encontrado en login.html');
  }
} else if (currentPage === 'register.html') {
  const registerForm = document.getElementById('registerForm');
  if (registerForm) {
    registerForm.addEventListener('submit', async (e) => {
      e.preventDefault();
      const nombre = document.getElementById('nombre').value;
      const apellido = document.getElementById('apellido').value;
      const cedula = document.getElementById('cedula').value;
      const celular = document.getElementById('celular').value;
      const email = document.getElementById('email').value;
      const contrasena = document.getElementById('contrasena').value;
      await handleRegister(nombre, apellido, cedula, celular, email, contrasena);
    });
  } else {
    console.error('Elemento con id "registerForm" no encontrado en register.html');
  }
}
=======
    alert('Credenciales incorrectas');
  }
});
>>>>>>> 47a79e34fec662558b14e38ab589974b0a06d8e4
