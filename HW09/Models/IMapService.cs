using System;
using System.Collections.Generic;
using System.Text;

namespace HW09.Models
{
    public interface IMapService
    {
        string GetDirections(string start, string end);
    }
}
