using myTGA_Common.Contracts;
using System;

namespace myTGA_Common.Entities {
    public class BaseEntity<T> : IEntity
        where T : IEquatable<T> {
        public T Id { get; set; }
    }
}
