using MediatR;
using NEXOSAPI.Domain.Entities;
using NEXOSAPI.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace NEXOSAPI.Service.Features.CustomerFeatures.Commands
{
    public class CreateAuthorCommand : IRequest<int>
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Gender { get; set; }
        public int NumberPages { get; set; }
        public int IdAuthor { get; set; }
        public class CreateCustomerCommandHandler : IRequestHandler<CreateAuthorCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateCustomerCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
            {
                var book = new Book();
                book.Gender = request.Gender;
                book.NumberPages = request.NumberPages;
                book.Title = request.Title;
                book.Year = request.Year;
                book.Author = _context.Authors.Find(request.IdAuthor);

                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                return book.Id;
            }
        }
    }
}
