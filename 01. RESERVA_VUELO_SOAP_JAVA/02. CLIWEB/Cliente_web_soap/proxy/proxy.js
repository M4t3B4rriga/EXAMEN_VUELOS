const express = require('express');
const cors = require('cors');
const bodyParser = require('body-parser');
const axios = require('axios');

const app = express();
const PORT = 3000;

app.use(cors());
app.use(bodyParser.json());

app.post('/soap', async (req, res) => {
  const { endpoint, soapAction, xmlBody } = req.body;

  try {
    const { data } = await axios.post(endpoint, xmlBody, {
      headers: {
        'Content-Type': 'text/xml;charset=UTF-8',
        'SOAPAction': soapAction || '',
      },
    });
    res.send(data);
  } catch (error) {
    console.error(error.message);
    res.status(500).send('Error en el servidor SOAP');
  }
});

app.listen(PORT, () => {
  console.log(`Proxy SOAP corriendo en http://localhost:${PORT}`);
});
