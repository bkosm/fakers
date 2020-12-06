defmodule FakersApiWeb.GraphQL.Resolvers.Query do
  alias FakersApi.People, as: Context

  def get_people(%{filter: filters}, _), do: {:ok, Context.list_people_by_filters(filters)}
  def get_people(_, _), do: {:ok, Context.list_people()}

  def get_deceased_people(%{filter: filters}, _), do: {:ok, Context.list_deceased_people_by_filters(filters)}
  def get_deceased_people(_, _), do: {:ok, Context.list_deceased_people()}

  def get_addresses(%{filter: filters}, _), do: {:ok, Context.list_addresses_by_filters(filters)}
  def get_addresses(_, _), do: {:ok, Context.list_addresses()}

  def get_contacts(%{filter: filters}, _), do: {:ok, Context.list_contacts_by_filters(filters)}
  def get_contacts(_, _), do: {:ok, Context.list_contacts()}

end
