using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Review;

public class UpdateReviewDto
{
    public string Comment { get; set; } = string.Empty;
    public int Rating { get; set; }
}
