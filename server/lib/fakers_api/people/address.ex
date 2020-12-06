defmodule FakersApi.People.Address do
  use Ecto.Schema
  import Ecto.Changeset
  alias FakersApi.People.PersonAddress

  schema "address" do
    field :city, :string
    field :location, :string
    field :street, :string
    field :voivodeship, :string

    has_many :person_addresses, PersonAddress
    has_many :people, through: [:person_addresses, :person]
  end

  @doc false
  def changeset(address, attrs) do
    address
    |> cast(attrs, [:street, :city, :voivodeship, :location])
    |> validate_required([:street, :city, :voivodeship, :location])
  end
end
