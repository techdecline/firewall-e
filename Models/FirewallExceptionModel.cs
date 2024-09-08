using System.ComponentModel.DataAnnotations;

namespace firewall_e.Models
{
    public class FirewallExceptionModel
    {
        [Required(ErrorMessage = "Source Address is required.")]
        [RegularExpression(@"^([0-9]{1,3}\.){3}[0-9]{1,3}(\/[0-9]{1,2})?$", ErrorMessage = "Invalid CIDR format.")]
        public string SourceAddress { get; set; }

        [Required(ErrorMessage = "Protocol is required.")]
        public string Protocol { get; set; }

        [Required(ErrorMessage = "FQDNs are required.")]
        [CustomValidation(typeof(FqdnValidator), nameof(FqdnValidator.ValidateFqdns))]
        public string Fqdns { get; set; }
    }

    public static class FqdnValidator
    {
        public static ValidationResult ValidateFqdns(string fqdns, ValidationContext context)
        {
            if (string.IsNullOrWhiteSpace(fqdns))
            {
                return new ValidationResult("FQDNs are required.");
            }

            var fqdnList = fqdns.Split(',');
            foreach (var fqdn in fqdnList)
            {
                if (!Uri.CheckHostName(fqdn.Trim()).Equals(UriHostNameType.Dns))
                {
                    return new ValidationResult("Invalid FQDN format.");
                }
            }
            return ValidationResult.Success;
        }
    }
}