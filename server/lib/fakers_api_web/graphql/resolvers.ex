defmodule FakersApiWeb.GraphQL.Resolvers do
  alias FakersApi.People, as: Context

  def get_people(%{filter: filters}, _resolution),
    do: {:ok, Context.list_people_by_filters(filters)}

  def get_people(_, _), do: {:ok, Context.list_people()}

  def get_address(%{id: id}, _resolution) do
    case Context.get_address(id) do
      nil ->
        {:error, "address not found, id=#{id}"}

      address ->
        {:ok, address}
    end
  end

  def get_contact(%{id: id}, _resolution) do
    case Context.get_contact(id) do
      nil ->
        {:error, "contact not found, id=#{id}"}

      contact ->
        {:ok, contact}
    end
  end
end
