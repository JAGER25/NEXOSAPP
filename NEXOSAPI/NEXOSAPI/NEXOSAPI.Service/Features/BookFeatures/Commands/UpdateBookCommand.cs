using MediatR;
using NEXOSAPI.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NEXOSAPI.Service.Features.CustomerFeatures.Commands
{
    public class UpdateAuthorCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Gender { get; set; }
        public int NumberPages { get; set; }
        public class UpdateCustomerCommandHandler : IRequestHandler<UpdateAuthorCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateCustomerCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
            {
                var book = _context.Books.Where(a => a.Id == request.Id).FirstOrDefault();

                if (book == null)
                {
                    return default;
                }
                else
                {
                    book.Gender = request.Gender;
                    book.NumberPages = request.NumberPages;
                    book.Title = request.Title;
                    book.Year = request.Year;
                    _context.Books.Update(book);
                    await _context.SaveChangesAsync();
                    return book.Id;
                }
            }
        }
    }
}
