export interface IPagedResult<T> {
    items: T;
    totalCount: number;
    pageIndex: number;
    pageSize: number;
}