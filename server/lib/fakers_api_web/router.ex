defmodule FakersApiWeb.Router do
  use FakersApiWeb, :router

  pipeline :graphql do
  end

  scope "/api" do
    pipe_through :graphql

    forward "/", Absinthe.Plug, schema: FakersApiWeb.GraphQL.Schema
  end

  # Enables LiveDashboard only for development
  #
  # If you want to use the LiveDashboard in production, you should put
  # it behind authentication and allow only admins to access it.
  # If your application does not have an admins-only section yet,
  # you can use Plug.BasicAuth to set up some basic authentication
  # as long as you are also using SSL (which you should anyway).
  if Mix.env() == :dev do
    import Phoenix.LiveDashboard.Router

    scope "/" do
      pipe_through [:fetch_session, :protect_from_forgery]
      live_dashboard "/dashboard", metrics: FakersApiWeb.Telemetry
    end

    forward "/graphiql", Absinthe.Plug.GraphiQL, schema: FakersApiWeb.GraphQL.Schema
  end
end
