using TicketingSystem.Services.DTOs;

namespace TicketingSystem.Services.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetUsersAsync(UserFiltersDTO Filters);
        void SeedUsersTable();
    }
}
