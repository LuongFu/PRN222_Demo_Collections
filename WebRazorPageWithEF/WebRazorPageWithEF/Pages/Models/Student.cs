using System;
using System.Collections.Generic;

namespace WebRazorPageWithEF.Pages.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstMidName { get; set; } = null!;

    public DateTime EnrollmentDate { get; set; }
}
