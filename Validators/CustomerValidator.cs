using FluentValidation;
using FluentValidation.Results;
using System.Net.Mail;
using webApi.Data.Dtos;
using webApi.Models;

namespace webApi.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator() 
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Customer name is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Customer last name is required");
            RuleFor(x => x.Cpf).NotEmpty().Must(BeAValidCpf).WithMessage("Cpf is required");
            RuleFor(x => x.Email).NotEmpty().Must(IsValidEmail).WithMessage("Email is required");
            RuleFor(x => x.Password).NotEmpty().Must(IsValidPassword).WithMessage("Password is required");

        }

        private bool BeAValidCpf(string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11 || new string(cpf[0], 11) == cpf)
            {
                return false;
            }

            int[] digits = cpf.Select(c => int.Parse(c.ToString())).ToArray();

            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum += digits[i] * (10 - i);
            }

            int remainder = sum % 11;
            int firstVerifierDigit = remainder < 2 ? 0 : 11 - remainder;

            if (digits[9] != firstVerifierDigit)
            {
                return false;
            }

            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += digits[i] * (11 - i);
            }

            remainder = sum % 11;
            int secondVerifierDigit = remainder < 2 ? 0 : 11 - remainder;

            if (digits[10] != secondVerifierDigit)
            {
                return false;
            }

            return true;
        }

        private bool IsValidPassword(string password)
        {
            // A senha deve ter no mínimo 6 caracteres
            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
                return false;

            // A senha deve ter pelo menos uma letra maiúscula, uma minúscula, um número e um caractere especial
            bool hasUpper = false, hasLower = false, hasDigit = false, hasSpecial = false;
            foreach (char c in password)
            {
                if (char.IsUpper(c))
                    hasUpper = true;
                else if (char.IsLower(c))
                    hasLower = true;
                else if (char.IsDigit(c))
                    hasDigit = true;
                else
                    hasSpecial = true;
            }

            return hasUpper && hasLower && hasDigit && hasSpecial;
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            try
            {
                // Tenta criar um endereço de e-mail a partir da string
                MailAddress mailAddress = new MailAddress(email);

                // Verifica se o endereço de e-mail possui um host
                return mailAddress.Host != null;
            }
            catch (FormatException)
            {
                // Se ocorrer uma exceção, é porque o endereço de e-mail é inválido
                return false;
            }
        }


    }
}
