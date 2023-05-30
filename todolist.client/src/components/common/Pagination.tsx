import Pagination from 'react-bootstrap/Pagination';

type PaginatorProps ={ 
    currentPage: number;
    pageSize: number;
    totalCount: number;
    onPageChange: (page: number) => void;
}

const PaginationController = ({currentPage, pageSize, totalCount, onPageChange}: PaginatorProps) => {
    let items = [];
    
    var pagesCount = totalCount % pageSize > 0 ? totalCount / pageSize + 1 : totalCount / pageSize;

    for (let number = 1; number <= pagesCount; number++) {
      items.push(
        <Pagination.Item key={number} active={number === currentPage} onClick={() => onPageChange(number)}>
          {number}
        </Pagination.Item>,
      );
    }

    return(
      <div className='mt-3 w-100 d-flex justify-content-center'>
      <Pagination>{items}</Pagination>
      </div>
    )
}


export default PaginationController;