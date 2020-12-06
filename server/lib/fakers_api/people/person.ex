defmodule FakersApi.People.Person do
  use Ecto.Schema
  import Ecto.Changeset
  alias FakersApi.People.{PersonAddress, PersonContact, DeceasedPerson}

  schema "person" do
    field :birth_date, :date
    field :first_name, :string
    field :last_name, :string
    field :pesel, :string
    field :second_name, :string
    field :sex, :string

    has_many :person_addresses, PersonAddress
    has_many :addresses, through: [:person_addresses, :address]

    has_many :person_contacts, PersonContact
    has_many :contacts, through: [:person_contacts, :contact]

    has_one :deceased_person, DeceasedPerson
  end

  @doc false
  def changeset(person, attrs) do
    person
    |> cast(attrs, [:pesel, :first_name, :second_name, :last_name, :sex, :birth_date])
    |> validate_required([:pesel, :first_name, :last_name, :sex, :birth_date])
    |> unique_constraint(:pesel)
  end
end
