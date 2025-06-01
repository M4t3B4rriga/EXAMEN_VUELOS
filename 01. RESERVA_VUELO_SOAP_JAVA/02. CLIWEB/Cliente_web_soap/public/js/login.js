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
  if (text.includes('true')) {
    sessionStorage.setItem('email', email);
    location.href = 'comprar-boletos.html';
  } else {
    alert('Credenciales incorrectas');
  }
});
