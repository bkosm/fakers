defmodule FakersApi.People.Contact do
  use Ecto.Schema
  import Ecto.Changeset

  schema "contact" do
    field :email, :string
    field :phone_number, :string
  end

  @doc false
  def changeset(contact, attrs) do
    contact
    |> cast(attrs, [:email, :phone_number])
    |> validate_required([:email])
  end
end
