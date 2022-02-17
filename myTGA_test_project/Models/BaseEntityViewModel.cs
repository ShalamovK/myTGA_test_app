using System;

namespace myTGA_test_project.Models {
    public class BaseEntityViewModel<T> where T : IEquatable<T> {
        public T Id { get; set; }
    }
}
