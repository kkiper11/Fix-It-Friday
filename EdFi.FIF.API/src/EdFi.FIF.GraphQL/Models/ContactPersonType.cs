﻿using EdFi.FIF.Core.Models;
using EdFi.FIF.GraphQL.Helpers;
using GraphQL.Types;
// ReSharper disable VirtualMemberCallInConstructor

namespace EdFi.FIF.GraphQL.Models
{
    public class ContactPersonType : ObjectGraphType<ContactPerson>
    {
        public ContactPersonType(ContextServiceLocator contextServiceLocator)
        {
            Field("uniquekey", x => x.UniqueKey);
            Field("contactpersonkey", x => x.ContactPersonKey);
            Field("studentkey", x => x.StudentKey);
            Field("contactfirstname", x => x.ContactFirstName);
            Field("contactlastname", x => x.ContactLastName);
            Field("relationshiptostudent", x => x.RelationshipToStudent);
            Field("streetnumbername", x => x.StreetNumberName);
            Field("apartmentroomsuitenumber", x => x.ApartmentRoomSuiteNumber);
            Field("state", x => x.State);
            Field("postalcode", x => x.PostalCode);
            Field("phonenumber", x => x.PhoneNumber);
            Field("primaryemailaddress", x => x.PrimaryEmailAddress);
            Field("isprimarycontact", x => x.IsPrimaryContact);
            Field("preferredcontactmethod", x => x.PreferredContactMethod);
            Field("besttimetocontact", x => x.BestTimeToContact);
            Field("contactnotes", x => x.ContactNotes);
        }
    }
}