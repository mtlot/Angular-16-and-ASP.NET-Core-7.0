const PROXY_CONFIG = [
    {
      context: ['/api'],
      target: 'http://localhost:5280',
      secure: false,
      logLevel: 'debug'
    }
  ]
  
  module.exports = PROXY_CONFIG;