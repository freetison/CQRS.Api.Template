using System;

namespace Api.Filters
{
    public interface IAttributeGroup
    {
        Attribute[] Process();
    }
}