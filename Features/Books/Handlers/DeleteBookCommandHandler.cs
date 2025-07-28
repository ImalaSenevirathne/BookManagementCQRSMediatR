using BookManagementCQRSMediatR.Data;
using BookManagementCQRSMediatR.Features.Books.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookManagementCQRSMediatR.Features.Books.Handlers
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly AppDbContext _context;

        public DeleteBookCommandHandler(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == request.BookId);

            if (book == null) return false;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
