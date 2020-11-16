defmodule FakersApiWeb.GraphQL.Schema.Types.Filters do
  use Absinthe.Schema.Notation

  @desc "Person filter type. Matches equal values."
  input_object :person_filter do
    field :id, :integer
    field :birth_date, :date
    field :first_name, :string
    field :second_name, :string
    field :last_name, :string
    field :pesel, :string
    field :sex, :string

    @desc "Set to true to filter deceased people."
    field :only_alive, :boolean, default_value: false
  end

  @desc "Deceased person filter type. Matches equal values."
  input_object :deceased_person_filter do
    field :person_id, :integer
    field :birth_date, :date
    field :first_name, :string
    field :second_name, :string
    field :last_name, :string
    field :pesel, :string
    field :sex, :string
    field :date_of_death, :date
  end

  @desc "Address filter type. Matches equal values."
  input_object :address_filter do
    field :id, :integer
    field :city, :string
    field :location, :string
    field :street, :string
    field :voivodeship, :string
  end

  @desc "Contact filter type. Matches equal values."
  input_object :contact_filter do
    field :id, :integer
    field :email, :string
    field :phone_number, :string
  end
end
