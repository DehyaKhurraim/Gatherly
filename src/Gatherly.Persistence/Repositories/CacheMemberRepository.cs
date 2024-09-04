using Gatherly.Domain.Entities;
using Gatherly.Domain.Repositories;

namespace Gatherly.Persistence.Repositories;

public class CacheMemberRepository : IMemberRepository
{
    private readonly MemberRepository _decorated;
    private readonly IMemoryCachce _memorycache;

    public CacheMemberRepository(MemeberRepository decorator, IMemoryCachce memorycache)
    {
        _decorated = decorator;
        _memorycache = memorycache;
    }

    public Task<Member?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        string key = $"member-{id}";
        return _memorycache.GetOrCreateAsync(
            key,
            entry => {
                entry.SetAbsouluteExpiration(
                    TimeSpan.FromMinutes(5));

                return _repository.GetById(id);
            });
    }

}