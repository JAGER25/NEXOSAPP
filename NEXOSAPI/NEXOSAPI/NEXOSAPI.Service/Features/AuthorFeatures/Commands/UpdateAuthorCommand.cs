using MediatR;
using NEXOSAPI.Persistence;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NEXOSAPI.Service.Features.AuthorFeatures.Commands
{
    public class UpdateAuthorCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateBirth { get; set; }
        public string CityOrigin { get; set; }

        public int IdMaximumBooks { get; set; }
        public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateAuthorCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
            {
                var author = _context.Authors.Where(a => a.Id == request.Id).FirstOrDefault();

                if (author == null)
                {
                    return default;
                }
                else
                {
                    author.CityOrigin = request.CityOrigin;
                    author.DateBirth = request.DateBirth;
                    author.FullName = request.FullName;
                    author.MaximumBooks = _context.MaximumBooks.Find(request.IdMaximumBooks);
                    _context.Authors.Update(author);
                    await _context.SaveChangesAsync();
                    return author.Id;
                }
            }
        }
    }
}
