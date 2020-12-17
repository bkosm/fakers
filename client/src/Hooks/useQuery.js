import useQueryParams from './useQueryParms';

const useQuery = (paramKey) => {
  return useQueryParams().get(paramKey);
};

export default useQuery;
