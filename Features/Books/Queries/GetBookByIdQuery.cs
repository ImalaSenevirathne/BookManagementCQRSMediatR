using BookManagementCQRSMediatR.Models;
using MediatR;

namespace BookManagementCQRSMediatR.Features.Books.Queries
{
    public class GetBookByIdQuery : IRequest<Book?>
    {
        public Guid BookId { get; set; }
    }
}
