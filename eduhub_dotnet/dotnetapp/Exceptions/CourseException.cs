using System;

namespace dotnetapp.Exceptions
{
public class CourseException : Exception
{
    public CourseException(string message) : base(message)
    {
    }
}

}