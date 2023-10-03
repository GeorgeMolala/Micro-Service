using Micro_Service.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Micro_Service.Data
{
    
        public static class FilterPrefix
        {
            
            public const string Client = "customer-";
            public const string AccountType = "type-";

        }


        public class RouteDictionary : Dictionary<string, string>
        {

            public int PageNumber
            {
                get => Get(nameof(GridDTO.PageNumber)).ToInt();
                set => this[nameof(GridDTO.PageNumber)] = value.ToString();
            }

            public int PageSize
            {
                get => Get(nameof(GridDTO.PageSize)).ToInt();
                set => this[nameof(GridDTO.PageSize)] = value.ToString();
            }

            public string SortField
            {
                get => Get(nameof(GridDTO.SortField));
                set => this[nameof(GridDTO.SortField)] = value;
            }

            public string SortDirection
            {
                get => Get(nameof(GridDTO.SortDirection));
                set => this[nameof(GridDTO.SortDirection)] = value;
            }

        public void ClearFilters() =>
            AccountTypeFilter = ClientFilter = ClientNameFilter = BankAccountGridDTO.DefaultFilter;



        private string Get(string key) => Keys.Contains(key) ? this[key] : null;


            public void SetSortAndDirection(string fieldName, RouteDictionary current)
            {

                this[nameof(GridDTO.SortField)] = fieldName;

                if (current.SortField.EqualsNoCase(fieldName) &&
                    current.SortDirection == "asc")
                    this[nameof(GridDTO.SortDirection)] = "desc";
                else
                    this[nameof(GridDTO.SortDirection)] = "asc";
            }
        public string AccountTypeFilter
        {
            get => Get(nameof(BankAccountGridDTO.AccountType))?.Replace(FilterPrefix.AccountType, "");
            set => this[nameof(BankAccountGridDTO.AccountType)] = value;
        }
        public string ClientNameFilter
        {
            get => Get(nameof(BankAccountGridDTO.Client))?.Replace(FilterPrefix.Client, "");
            set => this[nameof(BankAccountGridDTO.Client)] = value;
        }

        public string ClientFilter
        {
            get => Get(nameof(ClientGridDTO.AccountType))?.Replace(FilterPrefix.Client, "");
            set => this[nameof(ClientGridDTO.AccountType)] = value;
        }

        public RouteDictionary Clone()
            {
                var clone = new RouteDictionary();
                foreach (var key in Keys)
                {
                    clone.Add(key, this[key]);
                }
                return clone;
            }
        }
    }

