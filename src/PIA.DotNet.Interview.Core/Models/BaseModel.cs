using System;

namespace PIA.DotNet.Interview.Core.Models
{
#pragma warning disable CS0659 // Typ überschreibt Object.Equals(object o), überschreibt jedoch nicht Object.GetHashCode()
    public class BaseModel
#pragma warning restore CS0659 // Typ überschreibt Object.Equals(object o), überschreibt jedoch nicht Object.GetHashCode()
    {
        public Guid Id { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is BaseModel))
                return false;

            BaseModel model = (BaseModel)obj;
            return Id == model.Id;
        }
    }
}
