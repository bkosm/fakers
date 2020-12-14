defmodule FakersApiWeb.GraphQL.Schema.Types.Objects do
  use Absinthe.Schema.Notation
  import Absinthe.Resolution.Helpers
  alias FakersApi.People

  enum(:sort_order, values: [:asc, :desc])

  @desc "An object that defines an address."
  object :address do
    field :id, non_null(:id)
    field :city, non_null(:string)
    field :location, non_null(:string)
    field :street, non_null(:string)
    field :voivodeship, non_null(:string)

    @desc "List of people assigned to this address."
    field :people, list_of(:person), resolve: dataloader(People)

    @desc "List of person association defining objects."
    field :person_addresses, list_of(:person_address) do
      @desc "Sorting order for 'assigned' field."
      arg(:sort, :sort_order)
      @desc "Limit amount of pulled associations."
      arg(:limit, :integer)

      resolve(dataloader(People))
    end
  end

  @desc "An object that defines a contact."
  object :contact do
    field :id, non_null(:id)
    field :email, non_null(:string)
    field :phone_number, :string

    @desc "List of people reachable with this contact info."
    field :people, list_of(:person), resolve: dataloader(People)

    @desc "List of person association defining objects."
    @desc "List of person association defining objects."
    field :person_contact, list_of(:person_contact) do
      @desc "Sorting order for 'assigned' field."
      arg(:sort, :sort_order)
      @desc "Limit amount of pulled associations."
      arg(:limit, :integer)

      resolve(dataloader(People))
    end
  end

  @desc "An object that defines a person."
  object :person do
    field :id, non_null(:id)
    field :birth_date, non_null(:date)
    field :first_name, non_null(:string)
    field :last_name, non_null(:string)

    @desc "Polish unique person identifier."
    field :pesel, non_null(:string)
    field :second_name, :string
    field :sex, non_null(:string)

    @desc "List of addresses that are assigned to this person."
    field :addresses, list_of(:address), resolve: dataloader(People)

    @desc "List of contacts that are assigned to this person."
    field :contacts, list_of(:contact), resolve: dataloader(People)

    @desc "List of address association defining objects."
    field :person_addresses, list_of(:person_address) do
      @desc "Sorting order for 'assigned' field."
      arg(:sort, :sort_order)
      @desc "Limit amount of pulled associations."
      arg(:limit, :integer)

      resolve(dataloader(People))
    end

    @desc "List of contact association defining objects."
    field :person_contacts, list_of(:person_contact) do
      @desc "Sorting order for 'assigned' field."
      arg(:sort, :sort_order)
      @desc "Limit amount of pulled associations."
      arg(:limit, :integer)

      resolve(dataloader(People))
    end
  end

  @desc "An object that represents an association between a person and an address."
  object :person_address do
    field :person_id, non_null(:id)
    field :address_id, non_null(:id)
    @desc "The date at which given association had been inserted."
    field :assigned, non_null(:date)

    @desc "The associated person."
    field :person, list_of(:person), resolve: dataloader(People)

    @desc "The associated address."
    field :address, list_of(:address), resolve: dataloader(People)

    @desc "Is this contact considered the main one for associated person?"
    field :is_primary, non_null(:boolean)
  end

  @desc "An object that represents an association between a person and a contact."
  object :person_contact do
    field :person_id, non_null(:id)
    field :contact_id, non_null(:id)
    @desc "The date at which given association had been inserted."
    field :assigned, non_null(:date)

    @desc "The associated person."
    field :person, list_of(:person), resolve: dataloader(People)

    @desc "The associated address."
    field :contact, list_of(:contact), resolve: dataloader(People)

    @desc "Is this contact considered the main one for associated person?"
    field :is_primary, non_null(:boolean)
  end

  @desc "An object that represents a deceased person."
  object :deceased_person do
    field :person_id, non_null(:id)
    field :date_of_death, non_null(:date)

    @desc "The person's profile."
    field :person, non_null(:person), resolve: dataloader(People)
  end
end
