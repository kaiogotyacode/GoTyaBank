# GoTyaBank 🏦💲

A back-end code challenge offered by PicPay. Using .NET 7.0, EFCore, Postman & SQL Server.

<div align="center">
  <img width="100rem" src="https://portfolio-kaiogotya.s3.us-east-2.amazonaws.com/PICPAY-CHALLENGE.png">  
</div>

## Swagger

### API Methods

<div align="center">
  <img src="https://portfolio-kaiogotya.s3.us-east-2.amazonaws.com/api_methods.PNG">  
</div>


### Schema | API Methods

<div align="center">
  <img src="https://portfolio-kaiogotya.s3.us-east-2.amazonaws.com/schema.PNG">  
</div>


## TransferenciaController | Code Standardization | Good Practices

 ```cs
        [HttpPost]
        [Route("CreateLojista")]
        public async Task<IActionResult> CreateLojista([FromBody] LojistaVM lojistaVM)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                if (await _lojistaRepository.HasLojista(lojistaVM))
                    return Conflict(new { error = "UserID or E-mail already exists!", lojista = lojistaVM});

                var lojista = await _lojistaRepository.CreateLojista(lojistaVM);

                return Created("/API/[controller]/CreateLojista", lojista);
            }
            catch
            {
                return BadRequest(lojistaVM);
            }

        }
```

```cs
  [HttpPost]
  [Route("CreateUsuarioComum")]
  public async Task<IActionResult> CreateUsuarioComum(UsuarioComumVM usuarioComumVM)
  {
      if (!ModelState.IsValid)
          return BadRequest(ModelState);

      try
      {
          if (await _usuarioComumRepository.HasUsuarioComum(usuarioComumVM))
              return Conflict(new { error = "UserID or E-mail already exists!", usuario = usuarioComumVM });

          var usuario = await _usuarioComumRepository.CreateUsuarioComum(usuarioComumVM);
          return Created("/API/[controller]/CreateUsuarioComum", usuario);

      }
      catch
      {
          return BadRequest(usuarioComumVM);
      }

  }
```

```cs 
        [HttpPut]
        [Route("Transferir")]
        public async Task<IActionResult> Transferir(TransferenciaVM transferenciaVM)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var transferencia = await _usuarioComumRepository.Transferir(transferenciaVM);
                if (!transferencia)
                    return BadRequest(new {error = "Não foi possível seguir com a transferência!", transferencia = transferenciaVM});

                return Ok(new { message = "Transferência realizada com sucesso!", transferencia = transferenciaVM });                
            }
            catch
            {
                    return BadRequest();    
            }

        }
```

<div align="center">
  <b> Open to new ideas! </b>
</div>


