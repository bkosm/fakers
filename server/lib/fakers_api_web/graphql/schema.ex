defmodule FakersApiWeb.GraphQL.Schema do
  use Absinthe.Schema

  alias FakersApiWeb.GraphQL.Schema.Types.{Objects, Inputs, Filters}
  alias FakersApiWeb.GraphQL.Resolvers.{Query, Mutation}
  alias FakersApi.People

  import_types(Absinthe.Type.Custom)
  import_types(Objects)
  import_types(Inputs)
  import_types(Filters)

  query do
    @desc "Get a list of people that match the filter."
    field :people, list_of(:person) do
      arg(:filter, :person_filter)

      resolve(&Query.get_people/2)
    end

    @desc "Get a list of deceased people that match the filter."
    field :deceased_people, list_of(:deceased_person) do
      arg(:filter, :deceased_person_filter)

      resolve(&Query.get_deceased_people/2)
    end

    @desc "Get an address with given id."
    field :addresses, list_of(:address) do
      arg(:filter, :address_filter)

      resolve(&Query.get_addresses/2)
    end

    @desc "Get a contact with given id."
    field :contacts, list_of(:contact) do
      arg(:filter, :contact_filter)

      resolve(&Query.get_contacts/2)
    end
  end

  mutation do
    @desc "Create a new person. Sex must be 'm' or 'f'."
    field :create_person, :person do
      arg(:birth_date, non_null(:date))
      arg(:first_name, non_null(:string))
      arg(:last_name, non_null(:string))
      arg(:pesel, non_null(:string))
      arg(:second_name, :string)
      arg(:sex, non_null(:string))

      resolve(&Mutation.create_person/2)
    end

    @desc "Modify an existing person. Sex must be 'm' or 'f'."
    field :modify_person, :person do
      arg(:id, non_null(:id))
      arg(:birth_date, :date)
      arg(:first_name, :string)
      arg(:last_name, :string)
      arg(:pesel, :string)
      arg(:second_name, :string)
      arg(:sex, :string)

      resolve(&Mutation.update_person/2)
    end

    @desc "Create a new address."
    field :create_address, :address do
      arg(:city, non_null(:string))
      arg(:location, non_null(:string))
      arg(:street, non_null(:string))
      arg(:voivodeship, non_null(:string))

      resolve(&Mutation.create_address/2)
    end

    @desc "Modify an existing address."
    field :modify_address, :address do
      arg(:id, non_null(:id))
      arg(:city, :string)
      arg(:location, :string)
      arg(:street, :string)
      arg(:voivodeship, :string)

      resolve(&Mutation.update_address/2)
    end

    @desc "Create a new contact."
    field :create_contact, :contact do
      arg(:email, non_null(:string))
      arg(:phone_number, :string)

      resolve(&Mutation.create_contact/2)
    end

    @desc "Modify an existing contact."
    field :modify_contact, :contact do
      arg(:id, non_null(:id))
      arg(:email, :string)
      arg(:phone_number, :string)

      resolve(&Mutation.update_contact/2)
    end

    @desc "Register person as deceased."
    field :register_deceased, :deceased_person do
      arg(:person_id, non_null(:id))
      arg(:date_of_death, :date)

      resolve(&Mutation.create_deceased_person/2)
    end

    @desc "Remove person from the deceased registry."
    field :remove_deceased, :deceased_person do
      arg(:person_id, non_null(:id))

      resolve(&Mutation.remove_deceased_person/2)
    end

    @desc "Create a person address association"
    field :associate_person_address, :person_address do
      arg(:person_id, non_null(:id))
      arg(:address_id, non_null(:id))
      arg(:assigned, :date)
      arg(:is_primary, :boolean)

      resolve(&Mutation.create_person_address/2)
    end

    @desc "Modify a person address association (assigned or isPrimary fields)."
    field :modify_person_address, :person_address do
      arg(:person_id, non_null(:id))
      arg(:address_id, non_null(:id))
      arg(:assigned, :date)
      arg(:is_primary, :boolean)

      resolve(&Mutation.update_person_address/2)
    end

    @desc "Remove a person address association."
    field :remove_person_address, :person_address do
      arg(:person_id, non_null(:id))
      arg(:address_id, non_null(:id))

      resolve(&Mutation.remove_person_address/2)
    end

    @desc "Create a person contact association"
    field :associate_person_contact, :person_contact do
      arg(:person_id, non_null(:id))
      arg(:contact_id, non_null(:id))
      arg(:assigned, :date)
      arg(:is_primary, :boolean)

      resolve(&Mutation.create_person_contact/2)
    end

    @desc "Modify a person contact association (assigned or isPrimary fields)."
    field :modify_person_contact, :person_contact do
      arg(:person_id, non_null(:id))
      arg(:contact_id, non_null(:id))
      arg(:assigned, :date)
      arg(:is_primary, :boolean)

      resolve(&Mutation.update_person_contact/2)
    end

    @desc "Remove a person contact association."
    field :remove_person_contact, :person_contact do
      arg(:person_id, non_null(:id))
      arg(:contact_id, non_null(:id))

      resolve(&Mutation.remove_person_contact/2)
    end
  end

  @doc """
  Create the dataloader context.

  """
  def context(context) do
    loader =
      Dataloader.new()
      |> Dataloader.add_source(People, People.data())

    Map.put(context, :loader, loader)
  end

  @doc """
  Add dataloader do Absinthe plugins.

  """
  def plugins, do: [Absinthe.Middleware.Dataloader | Absinthe.Plugin.defaults()]
end
