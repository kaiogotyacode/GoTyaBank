using CodeChallenge02.ViewModels;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class NovoUsuarioFilterSW : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type == typeof(NovoUsuarioVM))
        {
            var isPessoaFisicaProperty = context.Type.GetProperties()
                .FirstOrDefault(p => p.Name == "isPessoaFisica");

            if (isPessoaFisicaProperty != null)
            {
                var isPessoaFisica = (bool)isPessoaFisicaProperty.GetValue(context);

                // Remove properties based on the value of isPessoaFisica
                if (isPessoaFisica)
                {
                    schema.Properties.Remove("CNPJ");
                    schema.Required.Remove("CNPJ");
                }
                else
                {
                    schema.Properties.Remove("CPF");
                    schema.Required.Remove("CPF");
                }
            }
        }
    }
}
