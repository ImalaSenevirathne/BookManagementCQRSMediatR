using BookManagementCQRSMediatR.Data;
using BookManagementCQRSMediatR.Features.Books.Queries;
using BookManagementCQRSMediatR.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookManagementCQRSMediatR.Features.Books.Handlers
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book?>
    {
        private readonly AppDbContext _context;
        public GetBookByIdQueryHandler(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.Id == request.BookId, cancellationToken);
        }
    }
}
