defmodule FakersApi.People.PersonAddress do
  use Ecto.Schema
  import Ecto.Changeset
  alias FakersApi.People.{Person, Address}

  @primary_key false
  schema "person_address" do
    field :assigned, :date
    field :is_primary, :boolean

    belongs_to :person, Person, primary_key: true
    belongs_to :address, Address, primary_key: true
  end

  @doc false
  def changeset(person_address, attrs) do
    person_address
    |> cast(attrs, [:assigned, :person_id, :address_id, :is_primary])
    |> unique_constraint(:composite_key, name: :person_address_pkey)
  end
end
