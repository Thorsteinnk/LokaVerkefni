using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LokaVerkefniCL;
using System.Collections.ObjectModel;
using System.Data.Entity;

namespace Lokaverkefni
{
    class LokaverkefniDataContext
    {
        LokaVerkefniCL.LokaverkefniDBContext context = new LokaverkefniDBContext();
        ObservableCollection<Address> adresses;
        public ObservableCollection<Address> Adresses
        {
            get
            {
                
                context.Adresses.Load();
                adresses = context.Adresses.Local;
                return adresses;
            }
        }
        ObservableCollection<Apartment> apartments;
        public ObservableCollection<Apartment> Apartments
        {
            get
            {
                
                context.Apartments.Load();
                apartments = context.Apartments.Local;
                return apartments;
            }
        }
        ObservableCollection<Contract> contracts;
        public ObservableCollection<Contract> Contracts
        {
            get
            {
                
                context.Contracts.Load();
                contracts = context.Contracts.Local;
                return contracts;
            }
        }
        ObservableCollection<Incident> incidents;
        public ObservableCollection<Incident> Incidents
        {
            get
            {
                
                context.Incidents.Load();
                incidents = context.Incidents.Local;
                return incidents;
            }
        }
        ObservableCollection<Tenant> tenants;
        public ObservableCollection<Tenant> Tenants
        {
            get
            {
                
                context.Tenants.Load();
                tenants = context.Tenants.Local;
                return tenants;
            }
        }
        ObservableCollection<Reference> references;
        public ObservableCollection<Reference> References
        {
            get
            {                
                context.References.Load();
                references = context.References.Local;
                return references;
            }
        }
        ObservableCollection<Zip> zip;
        public ObservableCollection<Zip> Zip
        {
            get
            {
                context.Zip.Load();
                zip = context.Zip.Local;
                return zip;
            }
        }
    }
}
