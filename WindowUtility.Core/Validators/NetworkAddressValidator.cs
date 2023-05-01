using System.ComponentModel.DataAnnotations;

namespace WindowUtility.Core.Validators
{
    public class NetworkAddressValidator:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return base.IsValid(value);
        }
    }
}
