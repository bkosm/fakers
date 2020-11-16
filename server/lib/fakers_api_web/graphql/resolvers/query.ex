defmodule FakersApiWeb.GraphQL.Resolvers.Query do
  alias FakersApi.People, as: Context

  def get_people(%{filter: filters}, _) do
    {:ok, Context.list_people_by_filters(filters)}
  end

  def get_people(_, _) do
    {:ok, Context.list_people()}
  end

  def get_deceased_people(%{filter: filters}, _) do
    {:ok, Context.list_deceased_people_by_filters(filters)}
  end

  def get_deceased_people(_, _) do
    {:ok, Context.list_deceased_people()}
  end

  def get_address(%{id: id}, _) do
    case Context.get_address(id) do
      nil ->
        {:error, "address not found, id=#{id}"}

      address ->
        {:ok, address}
    end
  end

  def get_contact(%{id: id}, _) do
    case Context.get_contact(id) do
      nil ->
        {:error, "contact not found, id=#{id}"}

      contact ->
        {:ok, contact}
    end
  end
end
