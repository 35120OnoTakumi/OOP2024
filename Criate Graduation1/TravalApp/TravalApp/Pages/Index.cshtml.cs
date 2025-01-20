using Microsoft.AspNetCore.Mvc.RazorPages;
using TravalApp.Models;

namespace TravalApp.Pages {
    public class IndexModel : PageModel {
        // �v���p�e�B�Ƃ��� SearchViewModel �����J
        public SearchViewModel SearchViewModel { get; set; } = new SearchViewModel();

        public void OnGet() {
            // ���������K�v�Ȃ炱���ōs��
            SearchViewModel = new SearchViewModel {
                Location = string.Empty,
                ErrorMessage = string.Empty
            };
        }

        public void OnPost(string location) {
            if (string.IsNullOrWhiteSpace(location)) {
                SearchViewModel.ErrorMessage = "Location cannot be empty.";
                return;
            }

            // �K�v�ȏ��� (��: �������ʂ̎擾�Ȃ�)
            // ����̓f���Ƃ��ăG���[���b�Z�[�W�̂�
            SearchViewModel.Location = location;
            SearchViewModel.ErrorMessage = $"Search for '{location}' is not yet implemented.";
        }
    }
}
