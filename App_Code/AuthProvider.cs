using System;
using System.Collections.Generic;
using System.Web;

public class AuthProvider
{
    public string Name { get; private set; }
    public string DisplayName { get; private set; }
    public string ImageUrl { get; private set; }

    public AuthProvider(string name, string displayName, string imageUrl)
    {
        Name = name;
        DisplayName = displayName;
        ImageUrl = imageUrl;
    }
}
