using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelLibrary;

namespace ServiceLibrary
{
    public class PrepareUserDto : IPrepareUserDto
    {
        public UserDto Prepare(User user)
        {
            if (user == null)
            {
                return null;
            }
            else
            {
                try
                {
                    UserDto userdto = new UserDto();
                    userdto.Id = user.Id;
                    userdto.Name = user.Name;
                    userdto.Username = user.Username;
                    userdto.Age = user.Age;
                    IList<Membership> memberships = user.Memberships;
                    IList<Role> roles = user.Roles;
                    IList<String> tokensList = new List<string>();
                   

                    // Add Memberships
                    if (memberships != null)
                    {
                        Console.Write(memberships);

                        Membership[] mArray = memberships.ToArray();
                        String[] memArray = new string[mArray.Length];

                        for (int count = 0; count < mArray.Length; count++)
                        {
                            memArray[count] = mArray[count].Name;
                        }
                        userdto.Memberships = memArray;
                    }
                    else
                    {
                        user.Memberships = null;
                    }

                    // Add Roles
                    if (roles != null)
                    {

                        Role[] rArray = roles.ToArray();
                        String[] rolesArray = new string[rArray.Length];

                        for (int count = 0; count < rArray.Length; count++)
                        {
                            rolesArray[count] = rArray[count].Name;
                        }

                        userdto.Roles = rolesArray;
                    }
                    else
                    {
                        user.Roles = null;
                    }

                    // Add tokens
                    if (roles != null)
                    {
 //                       Console.WriteLine("Role count "+roles.Count);

                        for (var count = 0; count < roles.Count; count++)
                        {
                            Role role = roles[count];
                            IList<Token> tokens = role.Tokens;

              //              Console.WriteLine("Token Count "+tokens.Count);

                            for (var tcount = 0; tcount < tokens.Count; tcount++)
                            {
                                Token token = tokens[tcount];

                                if(!tokensList.Contains(token.Name))
                                tokensList.Add(token.Name);
                            }
                        }
                        userdto.Tokens = tokensList;
                    }
                    else
                    {
                        tokensList = null;
                    }

                    return userdto;
                }

                catch (Exception e)
                {
                    Console.Write("There was some problem preparing Dto");
                    Console.Write(e.ToString());
                    return null;
                }
            }
           

        }
    }
}
