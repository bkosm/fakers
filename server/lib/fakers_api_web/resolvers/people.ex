defmodule FakersApiWeb.Resolvers.People do
    alias FakersApi.People

    def list_people(_args, _context) do
        {:ok, People.list_people()}
    end
end