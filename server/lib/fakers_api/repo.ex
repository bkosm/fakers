defmodule FakersApi.Repo do
  use Ecto.Repo,
    otp_app: :fakers_api,
    adapter: Ecto.Adapters.Postgres
end
