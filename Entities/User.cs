using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace confitec.Entities
{
  public class User
  {
    public User()
    {
      IsDeleted = false;
    }
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    [BirthDateValidation(ErrorMessage = "A data de nascimento deve ser anterior a data atual.")]
    public DateTime DataNascimento { get; set; }
    public enum Esc
    {
      Infantil,
      Fundamental,
      Médio,
      Superior
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Esc Escolaridade { get; set; }

    public bool IsDeleted { get; set; }

    public class BirthDateValidationAttribute : ValidationAttribute
    {
      protected override ValidationResult IsValid(object value, ValidationContext validationContext)
      {
        var birthDate = (DateTime)value;

        if (birthDate >= DateTime.Now)
        {
          return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
      }
    }

    public void Update(string nome, string sobrenome, string email, DateTime dataNascimento, Esc escolaridade)
    {
      Nome = nome;
      Sobrenome = sobrenome;
      Email = email;
      DataNascimento = dataNascimento;
      Escolaridade = escolaridade;
    }

    public void Delete()
    {
      IsDeleted = true;
    }
  }
}

