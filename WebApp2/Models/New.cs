using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class New
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Text { get; set; }

    public DateTime DatePost { get; set; }

    public New()
    {
        Id = Guid.NewGuid();
    }
    
}
