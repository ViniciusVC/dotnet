
// Proxy de acesso da aplicação. para o IP da API DotNet.

const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
    env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'https://localhost:7058';

const PROXY_CONFIG = [
  {
    context: [
      "api",
      "weatherforecast",
    ],
    target,
    secure: false
  }
]

module.exports = PROXY_CONFIG;


/*
// Exemplo de configuração
const proxyConfig = [
  {
    context: ['/api/v1', '/api/v2],
    target: 'https://example.com',
    secure: true,
    changeOrigin: true
  },
  {
    context: ['**'], // Rest of other API call
    target: 'http://somethingelse.com',
    secure: false,
    changeOrigin: true
  }
];
*/
