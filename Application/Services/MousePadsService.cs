using Application.Helpers;
using Application.Interfaces;
using DTOS.Mouse_pads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

public class MousePadsService : IMousePadsService
{
    public Task AddMousePadsAsync(AddMouse_padsDTO newCategory)
    {
        throw new NotImplementedException();
    }

    public Task DeleteMousePadsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<Mouse_padsDTO>> Filter(FilterParameters parametrs)
    {
        throw new NotImplementedException();
    }

    public Task<Mouse_padsDTO> GetMousePadByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Mouse_padsDTO>> GetMousePadsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<Mouse_padsDTO>> GetPagetMousePads(int pageSize, int pageNumber)
    {
        throw new NotImplementedException();
    }

    public Task UpdateMousePadsAsync(UpdateMouse_padsDTO categoryDto)
    {
        throw new NotImplementedException();
    }
}
