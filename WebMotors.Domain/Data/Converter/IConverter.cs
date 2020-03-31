using System;
using System.Collections.Generic;
using System.Text;

namespace WebMotors.Domain.Data.Converter
{
    public interface IConverter<TOrigin, TDestination>
    {
        TDestination Parse(TOrigin origin);

        List<TDestination> ParseList(List<TOrigin> origin);
    }
}
