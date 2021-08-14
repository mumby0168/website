using System.Data;
using FluentValidation;
using Website.Shared;

namespace Website.Client.Features.Blog
{
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(p => p.Id).NotEmpty().MinimumLength(5);
            RuleFor(p => p.Title).NotEmpty().MinimumLength(5);
            RuleFor(p => p.GistUrl).NotEmpty();
            RuleFor(p => p.RenderedHeightInPixels).NotEmpty();
            RuleFor(p => p.Description).NotEmpty().MinimumLength(25);
        }
    }
}