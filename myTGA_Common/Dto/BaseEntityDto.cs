using System;

namespace myTGA_Common.Dto {
    public class BaseEntityDto<T> where T : IEquatable<T> {
        public T Id { get; set; }
    }
}
