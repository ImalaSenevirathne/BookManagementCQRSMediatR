using MediatR;

namespace BookManagementCQRSMediatR.Features.Books.Commands
{
    public class UpdateBookTitleCommand : IRequest<bool>
    {
        public Guid BookId { get; set; }
        public string NewTitle { get; set; } = null!;
    }
}
