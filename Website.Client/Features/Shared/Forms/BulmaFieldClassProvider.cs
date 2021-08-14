using System;
using System.Linq;
using Microsoft.AspNetCore.Components.Forms;

namespace Website.Client.Features.Shared.Forms
{
    public class BulmaFieldClassProvider : FieldCssClassProvider
    {
        public override string GetFieldCssClass(EditContext editContext, in FieldIdentifier fieldIdentifier)
        {
            if (editContext.IsModified(fieldIdentifier) is false)
            {
                return String.Empty;
            }


            var isValid = !editContext.GetValidationMessages(fieldIdentifier).Any();
            return isValid ? "is-success" : "is-danger";
        }
    }
}