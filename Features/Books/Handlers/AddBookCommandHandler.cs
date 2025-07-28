using BookManagementCQRSMediatR.Data;
using BookManagementCQRSMediatR.Features.Books.Commands;
using BookManagementCQRSMediatR.Models;
using MediatR;

namespace BookManagementCQRSMediatR.Features.Books.Handlers
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, Guid>
    {
        private readonly AppDbContext _context;

        public AddBookCommandHandler(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Guid> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var newBook = new Book
            {
                Title = request.Title,
                Author = request.Author
            };

            _context.Books.Add(newBook);
            await _context.SaveChangesAsync(cancellationToken);
            return newBook.Id;
        }
    }
}
